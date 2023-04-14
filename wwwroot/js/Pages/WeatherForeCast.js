function ViewCountryForecast(data) {
    var id = data.value.id;
    var response = ForeCastData(data);
}

async function ForeCastData(data) {
    const response = await fetch('https://localhost:7125/WeatherWebApi/GetForeCastData/England');
    const json = await response.json();

    console.log(json.data[0]);
    getFormInstance().option("formData", json.data[0]);
}

function getFormInstance() {
    return $("#form").dxForm("instance");
}


