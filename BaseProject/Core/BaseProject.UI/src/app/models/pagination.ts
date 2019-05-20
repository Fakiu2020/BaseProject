export  class FilterBase {
    pageNumber: number;
    totalRecords: number;
    pageTotal: number;
    pageSize: number;
}

export class PagedResult<T> {
    entity: T;
    filters: FilterBase;

    constructor(){
        this.filters = new FilterBase();
    }
}
