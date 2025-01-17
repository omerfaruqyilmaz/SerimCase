﻿namespace SerimCase.Business.Abstract.Query
{
    public interface IDynamicQuery
    {
        Task<T> GetAsync<T>(int id);
        Task<List<T>> GetAllAsync<T>(string whereCondition, object? parameter = null);
        Task<(List<T> record, int count)> GetAllByPaginationAsync<T>(int page, int pageSize, string whereCondition, string orderBy);
    }
}
