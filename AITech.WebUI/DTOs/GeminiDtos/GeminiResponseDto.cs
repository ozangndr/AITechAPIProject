namespace AITech.WebUI.DTOs.GeminiDtos
{
    public class GeminiResponseDto
    {
        public List<Cantidate>? candidates { get; set; }
    }

    public class Cantidate
    {
        public Content? content { get; set; }
        public string? finishReason { get; set; }
        public int? index { get; set; }
    }
}
