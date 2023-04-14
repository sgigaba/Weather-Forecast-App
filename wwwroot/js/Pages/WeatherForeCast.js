function ViewCountryForecast(data) {
    var id = data.value.id;
    var response = ForeCastData(data);
}

async function ForeCastData(data) {
    const response = await fetch('https://localhost:7125/WeatherWebApi/GetForeCastData?data='+data.value.name);
    const json = await response.json();

    console.log(json.data[0]["Current"]);
    getFormInstance().option("formData", json.data[0]);
}

function getFormInstance() {
    return $("#form").dxForm("instance");
}

/*function LocationFormInstance() {
    return $("#location-form").dxForm("instance");
}*/




