using AITech.WebUI.DTOs.MessageDtos;
using AITech.WebUI.Services.MessageServices;
using Microsoft.AspNetCore.Mvc;

namespace AITech.WebUI.Controllers
{
    public class UIController(IMessageService _messageService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto model)
        {
            // 1. Modelin geçerliliğini kontrol et (Client-side doğrulama başarısızsa)
            if (ModelState.IsValid)
            {
                try
                {
                    // 2. Mesajı asenkron olarak API'ye gönder
                    // Servis metodunuzu çağırıyoruz ve işlemin bitmesini bekliyoruz.
                    await _messageService.CreateAsync(model);

                    // 3. Başarılı yanıtı AJAX'a JSON olarak döndür
                    return Json(new { success = true, message = "Mesajınız başarıyla gönderildi! Kısa süre içinde size dönüş yapacağız." });
                }
                catch (HttpRequestException ex)
                {
                    // API tarafında bir hata oluşursa (Örn: 500 Internal Server Error)
                    // Bu kısım, API'nin çalışmadığı veya hata döndürdüğü durumları yönetir.
                    // Loglama yapılması şiddetle önerilir.
                    return Json(new { success = false, message = "Sunucu tarafında geçici bir sorun oluştu. Lütfen tekrar deneyiniz." });
                }
                catch (Exception)
                {
                    // Diğer beklenmedik hatalar
                    return Json(new { success = false, message = "Mesaj gönderilirken beklenmedik bir hata oluştu." });
                }
            }

            // 4. Model Doğrulama (Validation) Başarısız olursa
            // Tüm doğrulama hatalarını toplayıp JSON olarak döndür
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);

            // Eğer Ajax tarafında birden fazla hata mesajını tek tek göstermek istenirse 'errors' listesi kullanılabilir.
            // Ancak şimdilik genel bir mesaj döndürüyoruz.
            return Json(new { success = false, message = "Lütfen tüm alanları doğru ve eksiksiz doldurun." });
        }
    }
}
