function ViewCountryForecast(data) {
    ForeCastData(data);
}

function ViewDailyForeCast(data) {
    return $("#DailyDataGrid").dxDataGrid("instance").filter(["data", "=", data.value]);
}

async function ForeCastData(data) {
    const response = await fetch('https://localhost:7125/WeatherWebApi/GetForeCastData?data='+data.value.name);
    const json = await response.json();

    getFormInstance().option("formData", json.data[0]);
}

function getFormInstance() {
    return $("#form").dxForm("instance");
}