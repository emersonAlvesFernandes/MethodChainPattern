using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MethodChaining.Models
{
    public static class ResultAsyncExtensions
    {
        public static async Task<Result> OnSuccessAsync(this Task<Result> result, Func<Task<Result>> func)
        {
            var r = await result;

            if (r.Failure)
                return r;

            return await func();
        }
        public static async Task<Result<T>> OnSuccessAsync<T>(this Task<Result<T>> result, Func<T, Task<Result<T>>> func)
        {
            var r = await result;

            if (r.Failure)
                return r;

            return await func(r.Value);
        }

        public static async Task OnSuccessAsync(this Task<Result> result, Action action)
        {
            var r = await result;

            if (r.Failure)
                action();
        }


        public static async Task<Result> OnFailureAsync(this Task<Result> result, Action action)
        {
            var r = await result;

            if (r.Failure)
                action();
            
            return await Task.Run(()=> result);
        }
        public static async Task<Result<T>> OnFailureAsync<T>(this Task<Result<T>> result, Action action)
        {
            var r = await result;

            if (r.Failure)
                action();

            return await Task.Run(() => result);
        }
    }
}
