document.addEventListener("DOMContentLoaded", () => {
    const counterElement = document.getElementById("counter");
    const functionApiUrl = 'https://getvisitcounts.azurewebsites.net/api/GetVisitCounts?';
    //const functionApiUrl = 'http://localhost:7071/api/GetVisitCounts';

    async function getVisitCount() {
        try {
            const response = await fetch(functionApiUrl);
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }

            const count = await response.json();
            if (count !== undefined) {
                counterElement.textContent = count;
            } else {
                counterElement.textContent = "No data available";
            }
        } catch (error) {
            console.error("Error fetching visit count:", error);
            counterElement.textContent = "Error loading count";
        }
    }

    // Call the function to get the visit count and update the HTML
    getVisitCount();
});
