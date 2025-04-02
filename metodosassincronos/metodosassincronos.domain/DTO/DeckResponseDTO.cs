namespace metodosassincronos.domain.DTO
{
    public struct DeckResponseDTO
    {
        public bool Success { get; set; } 
        public string DeckId { get; set; } 
        public int Remaining { get; set; } 
        public bool Shuffled { get; set; } 
    }

}
