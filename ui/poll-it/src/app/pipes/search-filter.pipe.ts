import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: 'searchFilter'
})
export class SearchFilter implements PipeTransform {
    transform(items: any[], search: string, property: string): any[] {
        if (!items) { return []; }
        if (!search || !property) { return items; }

        search = search.toLowerCase();
        return items.filter(item => {
            return item[property].toLowerCase().includes(search);
        });
    }
}
