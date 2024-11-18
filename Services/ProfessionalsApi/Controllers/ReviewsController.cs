using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfessionalsApi.Data;
using ProfessionalsApi.Models;
using ProfessionalsApi.Repository.IRepository;

namespace ProfessionalsApi.Controllers
{
    [Route("api/User/Reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewsController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet("ReviewById/{id}")]
        public async Task<ActionResult<ResponseDTO>> ReviewById(int id)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _reviewRepository.GetReviewById(id),
            };
            return Ok(response);
        }

        [HttpGet("GetReviewsByName")]
        public async Task<ActionResult<ResponseDTO>> GetReviews(string username)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _reviewRepository.GetReviewsByProfessional(username),
            };
            return Ok(response);
        }

        [HttpPost("AddReview")]
        public async Task<ActionResult<ResponseDTO>> AddReview(Reviews reviews)
        {
            var response = new ResponseDTO()
            {
                IsSuccessful = true,
                Result = await _reviewRepository.PostReview(reviews),
            };
            return Ok(response);
        }


    }
}
