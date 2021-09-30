import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'prefix'
})
export class PrefixPipe implements PipeTransform {
  transform(value: number, prefix: string, ...args: unknown[]): unknown {
    return prefix + value.toString().split('').join('');
  }
}
