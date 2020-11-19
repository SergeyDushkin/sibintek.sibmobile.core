using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace sibintek.sibmobile.core
{   
    public interface IQueryInfo<T>
    {  
        // Разрешенный набор полей для сортировки
        // Настраивается для каждого списка
        // если не указано, сортировка запрещена
        IEnumerable<ISortField> AllowSortField { get; set; }
        
        // Текущие настройки поиска и сортировки
        ISortablePaginationQuery<T> Query { get; set; }
        
        // Общее количиство найденных записей
        long TotalCount { get; set; }
        
        // Количество записей в ответе
        long PageCount { get; set; }
        
        // Лимит на максимальное количесто записей полученных за один раз
        // Настраивается на сервере 
        long PageLimit { get; set; }

        // Идентификатор последнего элемента страницы
        // для получения следующей страницы передаем идентификатор в запросе
        T LastIdentity { get; set; }
    }

    public interface IQueryInfo
    {  
        // Разрешенный набор полей для сортировки
        // Настраивается для каждого списка
        // если не указано, сортировка запрещена
        IEnumerable<ISortField> AllowSortField { get; set; }
        
        // Текущие настройки поиска и сортировки
        ISortablePaginationQuery Query { get; set; }
        
        // Общее количиство найденных записей
        long TotalCount { get; set; }
        
        // Количество записей в ответе
        long PageCount { get; set; }
        
        // Лимит на максимальное количесто записей полученных за один раз
        // Настраивается на сервере 
        long PageLimit { get; set; }

        // Номер страницы
        int Page { get; set; }
    }

    public interface ISortField
    {
        string Name { get; set; }
        string Title { get; set; }
    }

    public interface ISort : ISortField
    {
        // Allow value
        // - asc
        // - desc
        string Order { get; set; }
    }

    public interface ISortableQuery : IQuery
    {
        ISort Sort { get; set; }
    }

    public interface ISortablePaginationQuery<T> : ISortableQuery
    {
        T LastIdentity { get; set; }
    }

    public interface ISortablePaginationQuery : ISortableQuery
    {
        long PageLimit { get; set; }
        int Page { get; set; }
    }
}
