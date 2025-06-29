using EBookStore.Domain;
using EBookStore.Domain.Domain;
using EBookStore.Domain.DTO;
using EBookStore.Repository.Interface;
using EBookStore.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Book> _productRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<BookInOrder> _productInOrderRepository;
        private readonly IEmailService _emailService;

        public ShoppingCartService(IUserRepository userRepository, IRepository<ShoppingCart> shoppingCartRepository, IRepository<Book> productRepository, IRepository<Order> orderRepository, IRepository<BookInOrder> productInOrderRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _productInOrderRepository = productInOrderRepository;
            _emailService = emailService;
        }

        public ShoppingCart AddProductToShoppingCart(string userId, AddToCartDTO model)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userCart = loggedInUser?.UserCart;

                var selectedProduct = _productRepository.Get(model.SelectedProductId);

                if (selectedProduct != null && userCart != null)
                {
                    userCart?.ProductInShoppingCarts?.Add(new BookInShoppingCart
                    {
                        Book = selectedProduct,
                        BookId = selectedProduct.Id,
                        ShoppingCart = userCart,
                        ShoppingCartId = userCart.Id,
                        Quantity = model.Quantity
                    });

                    return _shoppingCartRepository.Update(userCart);
                }
            }
            return null;
        }

        public bool deleteFromShoppingCart(string userId, Guid? Id)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);


                var product_to_delete = loggedInUser?.UserCart?.ProductInShoppingCarts.First(z => z.BookId == Id);

                loggedInUser?.UserCart?.ProductInShoppingCarts?.Remove(product_to_delete);

                _shoppingCartRepository.Update(loggedInUser.UserCart);

                return true;

            }

            return false;
        }

        public AddToCartDTO getProductInfo(Guid Id)
        {
            var selectedProduct = _productRepository.Get(Id);
            if (selectedProduct != null)
            {
                var model = new AddToCartDTO
                {
                    SelectedProductName = selectedProduct.Title.ToString(),
                    SelectedProductId = selectedProduct.Id,
                    Quantity = 1
                };
                return model;
            }
            return null;
        }

        public ShoppingCartDTO getShoppingCartDetails(string userId)
        {
            if (userId != null && !userId.IsNullOrEmpty())
            {
                var loggedInUser = _userRepository.Get(userId);

                var allProducts = loggedInUser?.UserCart?.ProductInShoppingCarts?.ToList();

                var totalPrice = 0.0;

                foreach (var item in allProducts)
                {
                    totalPrice += Double.Round((item.Quantity * item.Book.Price), 2);
                }

                var model = new ShoppingCartDTO
                {
                    AllBooks = allProducts,
                    TotalPrice = totalPrice
                };

                return model;

            }

            return new ShoppingCartDTO
            {
                AllBooks = new List<BookInShoppingCart>(),
                TotalPrice = 0.0
            };
        }

        public bool orderProducts(string userId)
        {
            if (userId != null)
            {
                var loggedInUser = _userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;
                EmailMessage message = new EmailMessage();
                message.Subject = "Successfull order";
                message.MailTo = loggedInUser.Email;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    OwnerId = userId,
                    Owner = loggedInUser
                };

                _orderRepository.Insert(order);

                List<BookInOrder> productInOrder = new List<BookInOrder>();

                var lista = userShoppingCart.ProductInShoppingCarts.Select(
                    x => new BookInOrder
                    {
                        Id = Guid.NewGuid(),
                        BookId = x.Book.Id,
                        OrderedProduct = x.Book,
                        OrderId = order.Id,
                        Order = order,
                        Quantity = x.Quantity
                    }
                    ).ToList();

                productInOrder.AddRange(lista);

                foreach (var product in productInOrder)
                {
                    var book = _productRepository.Get(product.BookId);

                     book.QuantityAvaiable -= product.Quantity;
                    _productRepository.Update(book);  
                        
                    _productInOrderRepository.Insert(product);
                }

                loggedInUser.UserCart.ProductInShoppingCarts.Clear();
                _userRepository.Update(loggedInUser);
                this._emailService.SendEmailAsync(message);
                return true;
            }
            return false;
        }
    }
}
