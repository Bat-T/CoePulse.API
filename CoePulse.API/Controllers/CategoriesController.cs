using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoePulse.API.Data;
using CoePulse.API.Models.Domain;
using CoePulse.API.Models.DTO;
using CoePulse.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;

namespace CoePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<CategoryDTO>> PostCategory(CreateCategoryRequestDTO request)
        {
            var category = new Category { Name = request.Name, UrlHandle = request.UrlHandle };

            await categoryRepository.CreateAsync(category);

            if(category == null) { return BadRequest("Bad Request"); }
            var categoryDTO = new CategoryDTO {Id = category.Id, Name = category.Name,UrlHandle = category.UrlHandle};
            return Ok(categoryDTO);
        }

        [HttpGet("GetAllCategory")]
        public async Task<ActionResult<List<CategoryDTO>>> GetAllCategory()
        {
            var allCategory = await categoryRepository.GetAllCategory();

            var res = new List<CategoryDTO>();
            foreach (var category in allCategory)
            {
                res.Add(new CategoryDTO { Id=category.Id, Name = category.Name, UrlHandle = category.UrlHandle });
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(Guid id)
        {
            var categ = await categoryRepository.GetCategoryByID(id);
            if (categ == null) { return NotFound(); }
            var categoryDTO = new CategoryDTO { Id = categ.Id, Name = categ.Name, UrlHandle = categ.UrlHandle };
            return Ok(categoryDTO);
        }


        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<CategoryDTO>> EditCategory([FromRoute] Guid id,UpdateRequestDTO updateRequest)
        {
            var request = new Category
            {
                Id = id,
                Name = updateRequest.Name,
                UrlHandle = updateRequest.UrlHandle,
            };

            var output = await categoryRepository.UpdateCategory(request);

            if (output == null) { return NotFound(); }

            return Ok(output);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<ActionResult<CategoryDTO>> DeleteCategory([FromRoute] Guid id)
        {
            

            var output = await categoryRepository.DeleteCategoryByID(id);

            if (output == null) { return NotFound(); }


            return Ok(output);
        }

    }
}
