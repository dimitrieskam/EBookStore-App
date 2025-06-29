using EBookStore.Domain.Domain;
using EBookStore.Domain.DTO;
using EBookStore.Domain.Identity;
using EBookStore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<EBookStoreAppUser> _userManager;
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly IAuthorService _authorService;
        public AdminController(IOrderService orderService, UserManager<EBookStoreAppUser> userManager,IBookService bookService, IPublisherService publisherService, IAuthorService authorService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _bookService = bookService;
            _publisherService = publisherService;
            _authorService = authorService;
        }
        [HttpGet("[action]")]
        public List<Order> GetAllOrders()
        {
            return this._orderService.GetAllOrders();
        }
        
        [HttpPost("[action]")]
        public Order GetDetails(BaseEntity id)
        {
            return this._orderService.GetDetailsForOrder(id);
        }

       

        [HttpPost("[action]")]
        public bool ImportAllAuthors(List<AuthorDTO> model)
        {
            bool status = true;

            foreach (var item in model)
            {

                var author = new Author
                {
                    Name = item.Name,
                    Surname = item.Surname,
                    AuthorImage = item.AuthorImage,
                    Biography = item.Biography
                };

                _authorService.CreateNewAuthor(author);

            }
            return status;
        }
        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            return _orderService.GetDetailsForOrder(model);
        }

    }
}
