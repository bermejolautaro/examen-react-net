using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExamenReactNet.Core
{
    public class Result<T>
    {
        public T Value { get; }
        public bool IsSuccessful { get; private set; }
        public IEnumerable<string> Errors { get; private set; } = Enumerable.Empty<string>();

        private Result(T value)
        {
            Value = value;
            IsSuccessful = true;
        }

        private Result(IEnumerable<string> errors)
        {
            Errors = errors;
            IsSuccessful = false;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Error(params string[] errors)
        {
            return new Result<T>(errors);
        }

        public static Result<T> Error(IEnumerable<string> errors)
        {
            return new Result<T>(errors);
        }
    }
}
