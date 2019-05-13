export  class Pagination {
    pageNumber: number;
    totalRecords: number;
    pageTotal: number;
    pageSize: number;    
}

export class PaginatedResult<T> {
    result: T;
    pagination: Pagination;
    
}
