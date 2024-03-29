﻿using System.ComponentModel.DataAnnotations;
using Junetic.Common.Abstractions;
using Microsoft.Extensions.Options;

namespace Junetic.Common.Utilities;

/// <summary>
/// Validates options by fields Data Annotations  
/// </summary>
public sealed class OptionsValidator<TOptions> : IValidateOptions<TOptions> where TOptions : class, ISettings {

	//todo check if it even works line for throwing on missing required fields and whole blocks (config classes)


	/// <inheritdoc />
	public ValidateOptionsResult Validate(string name, TOptions options) {
		//todo do we need to check options for null?
		
		ValidationContext validationContext = new ValidationContext(options);
		List<ValidationResult> validationResults = new List<ValidationResult>();
		bool noValidationErrorsOccured = Validator.TryValidateObject(options, validationContext, validationResults, true);

		if(noValidationErrorsOccured) {
			return ValidateOptionsResult.Success;
		}

		IEnumerable<string?> validationFailures = validationResults.Select(validationResult => validationResult.ErrorMessage);

		return ValidateOptionsResult.Fail(validationFailures);
	}

}