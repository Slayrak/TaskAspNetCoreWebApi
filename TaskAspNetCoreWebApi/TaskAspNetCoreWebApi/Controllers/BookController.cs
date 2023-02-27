using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TaskAspNetCoreWebApi.Business.Validators;
using TaskAspNetCoreWebApi.Domain.DTO;
using TaskAspNetCoreWebApi.Domain.Interfaces;
using TaskAspNetCoreWebApi.Domain.Interfaces.Services;
using TaskAspNetCoreWebApi.Domain.Models;
using TaskAspNetCoreWebApi.Domain.OptionsClasses;
using static System.Reflection.Metadata.BlobBuilder;

namespace TaskAspNetCoreWebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;
        private readonly IMapper _mapper;
        private readonly Secret _secret;

        public BookController(IBookService bookService, ILogger<BookController> logger, IMapper mapper, IOptions<Secret> options)
        {
            _bookService = bookService;
            _logger = logger;
            _mapper = mapper;
            _secret = options.Value;
        }

        [HttpGet(Name ="GetAllBooks")]
        public async Task<IActionResult> GetAllBooks([FromQuery]string order)
        {

            var res = await _bookService.GetAll(order);

            var booksToPass = new List<BookDTO>();

            if(order.ToLower() == "author" || order.ToLower() == "title")
            {
                foreach (var book in res)
                {
                    var bookDTO = _mapper.Map<BookDTO>(book);

                    bookDTO.ReviewsNumber = book.Reviews.Count;
                    bookDTO.Rating = (decimal?)book.Ratings.Select(x => x.Score).Average();

                    booksToPass.Add(bookDTO);
                }

                return Ok(booksToPass);
            }

            return BadRequest("Incorrect order parameter");
        }

        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetBook(long id)
        {
            var book = await _bookService.GetBook(id);

            var bookDTO = _mapper.Map<DetailedBookDTO>(book);

            bookDTO.Rating = (decimal)book.Ratings.Select(x => x.Score).Average();

            return Ok(bookDTO);

        }

        [HttpDelete]
        [Route("{id:long}")]
        public async Task<IActionResult> DeleteBook(long id, [FromQuery]string secret)
        {
            if(_secret.SecretWord.Equals(secret))
            {
                await _bookService.Delete(id);

                return Ok();
            }

            return BadRequest("Secret word is not correct");
                
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> AddBook([FromBody]AddBookDTO book)
        {
            BookValidator validations = new BookValidator();

            ValidationResult result = validations.Validate(book);

            if (!result.IsValid)
            {
                var err = "";

                foreach (var failure in result.Errors)
                {
                    err += $"{failure.PropertyName}: {failure.ErrorMessage}";
                }

                return BadRequest(err);
            }


            long id = await _bookService.AddBook(_mapper.Map<Book>(book));

            var res = new Dictionary<string, long>
            {
                { "id", id }
            };

            return Ok(res);
        }

        [HttpPut]
        [Route("{id:long}/review")]
        public async Task<IActionResult> AddReview(long id, [FromBody]AddReviewDTO reviewDTO)
        {

            ReviewValidator validations = new ReviewValidator();

            ValidationResult result = validations.Validate(reviewDTO);

            if (!result.IsValid)
            {
                var err = "";

                foreach (var failure in result.Errors)
                {
                    err += $"{failure.PropertyName}: {failure.ErrorMessage}";
                }

                return BadRequest(err);
            }

            long returnId = await _bookService.AddReview(id, _mapper.Map<Review>(reviewDTO));

            var res = new Dictionary<string, long>
            {
                { "id", returnId }
            };

            return Ok(res);
        }

        [HttpPut]
        [Route("{id:long}/rate")]
        public async Task<IActionResult> AddRate(long id, [FromBody] RatingDTO ratingDTO)
        {
            RateValidator validations = new RateValidator();

            ValidationResult result = validations.Validate(ratingDTO);

            if(!result.IsValid)
            {
                var err = "";

                foreach(var failure in result.Errors)
                {
                    err += $"{failure.PropertyName}: {failure.ErrorMessage}";
                }

                return BadRequest(err);
            }

            await _bookService.AddRating(id, _mapper.Map<Rating>(ratingDTO));

            return Ok();
        }

        [HttpGet]
        [Route("/api/recommended")]
        public async Task<IActionResult> GetRecommended([FromQuery] string genre)
        {
            var books = await _bookService.GetRecommends(genre);

            var booksToPass = new List<BookDTO>();

            foreach (var book in books)
            {
                var bookDTO = _mapper.Map<BookDTO>(book);

                bookDTO.ReviewsNumber = book.Reviews.Count;
                bookDTO.Rating = (decimal?)book.Ratings.Select(x => x.Score).Average();

                booksToPass.Add(bookDTO);
            }

            return Ok(booksToPass);

        }

    }
}
