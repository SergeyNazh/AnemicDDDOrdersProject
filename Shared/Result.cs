using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public class Result
	{
		public string? ErrorMessage { get; }
		public bool IsSuccess => ErrorMessage is null;
		protected Result() { }
		protected Result(string errorMessage)
		{
			ErrorMessage = errorMessage;
		}
		public static Result Success() => new Result();
		public static Result Failure(string errorMessage) => new Result(errorMessage);
	}
	public class Result<TResult> : Result
	{
		public TResult? Value { get; }
		protected Result(TResult value)
		{
			Value = value;
		}
		protected Result(string errorMessage) : base(errorMessage) { }
		public new static Result<TResult> Failure(string errorMessage) => new Result<TResult>(errorMessage);
		public new static Result<TResult> Success(TResult value) => new Result<TResult>(value);
	}
}
