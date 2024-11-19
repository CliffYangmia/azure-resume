window.addEventListener('DOMContentLoaded', (event) =>{
    getVisitCount();
})

const functionApiUrl = 'https://getvisitcounts.azurewebsites.net/api/GetVisitCounts?';
const localfunctionApi = 'http://localhost:7071/api/GetVisitCounts';

const getVisitCount = () => {
    let count = 0;
    fetch(functionApiUrl).then(response => {
        console.log(response);
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count = response;
        document.getElementById("counter").innerText = count;
    }).catch(function(error){
        console.log(error);
    })
}