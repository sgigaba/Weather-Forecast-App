namespace Weather_Forecast_App.Validators
{
    using FluentValidation;
    using Weather_Forecast_App.Models.Weather;

    public class CurrentWeatherValidator : AbstractValidator<CurrentWeather>
    {
        public CurrentWeatherValidator() {
            this.RuleFor(_ => _.temp_c)
                .NotNull();
        }
    }
}
