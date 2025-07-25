﻿namespace AWC.Infra.Results
{
    public class PaginatedQueryResult<T>
    {
        public IList<T>? Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
