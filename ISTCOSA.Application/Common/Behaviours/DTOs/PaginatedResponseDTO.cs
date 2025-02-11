﻿namespace ISTCOSA.Application.Common.DTOs
{
    public class PaginatedResponseDTO<T>
    {
      
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Data { get; set; }
    }
}
