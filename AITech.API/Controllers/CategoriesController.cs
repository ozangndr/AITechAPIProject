using AITech.Business.Services.CategoryServices;
using AITech.DTO.CategoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AITech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.TGetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.TGetByIdAsync(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {            
            await _categoryService.TCreateAsync(createCategoryDto);
            return Ok("Kategori Oluşturuldu");

        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.TUpdateAsync(updateCategoryDto);
            return Ok("Kategori Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _categoryService.TDeleteAsync(id);
                // Başarılıysa 204 No Content dönerek Body'de gereksiz metin göndermekten kaçının.
                return NoContent();
            }
            catch (Exception ex)
            {
                // Loglama yapın: Hatanın detayını burada loglamak çok önemlidir!
                // _logger.LogError(ex, "Kategori silinirken hata oluştu.");

                // Kullanıcıya anlaşılır bir mesaj ve 400 Bad Request dönmek daha iyi.
                return BadRequest("Silme işlemi başarısız. Bu kategoriye bağlı Projeler olabilir veya bir veritabanı kısıtlaması ihlal edilmiş olabilir.");

                // Eğer hata gerçekten bilinmeyen bir sunucu hatasıysa 500 dönebilirsiniz.
                // return StatusCode(500, "Sunucu tarafında beklenmedik bir hata oluştu.");
            }
        }

    }
}
