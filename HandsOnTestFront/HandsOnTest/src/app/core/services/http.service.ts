import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Options {
  headers?: HttpHeaders;
  params?: HttpParams;
}

export class HttpService {

  constructor(protected http: HttpClient) { }

  protected createDefaultOptions(): Options {
      return {
          headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };
  }

  protected optsName(name: string): Options {
      const newopts = this.createDefaultOptions();

      newopts.headers['xhr-name'] = name;

      return newopts;
  }

  protected createOptions(opts: Options): Options {
      const defaultOpts: Options = this.createDefaultOptions();

      if (opts) {
          opts = {
              params: opts.params || defaultOpts.params,
              headers: opts.headers || defaultOpts.headers
          };

          if (!opts.headers['Content-Type']) {
              opts.headers['Content-Type'] = defaultOpts.headers['Content-Type'];
          }
      }

      return opts || defaultOpts;
  }


  protected doGet<T>(serviceUrl: string, opts?: Options): Observable<T> {
      const ropts = this.createOptions(opts);

      return this.http.get<T>(serviceUrl, ropts);
  }

}
