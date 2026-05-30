const API_BASE = "http://localhost:5191/api/f1";

const loadBtn = document.getElementById('load-btn');
const sessionInput = document.getElementById('session-input');
const teamsContainer = document.getElementById('teams-container');
const driversContainer = document.getElementById('drivers-container');

const renderTeams = (teams) => {
        teamsContainer.replaceChildren();

        teams.forEach(team => {
            const teamDiv = document.createElement('div');
            teamDiv.classList.add('team-item');
            teamDiv.style.borderLeftColor = `#${team.teamColor}`;

            const strongName = document.createElement('strong');
            strongName.textContent = team.teamName;

            const countDiv = document.createElement('div');
            countDiv.classList.add('team-driver-count');
            countDiv.textContent = `Drivers Active: ${team.totalDrivers}`;

            teamDiv.append(strongName, countDiv);
            teamsContainer.append(teamDiv);
        })
    }

    const renderDrivers = (drivers) => {
        driversContainer.replaceChildren();

        if(drivers.length === 0) {
            const noDataMsg = document.createElement('p');
            noDataMsg.classList.add('no-data-message');
            noDataMsg.textContent = "No active driver data found for this session.";
            driversContainer.append(noDataMsg);
            return;
        }

        drivers.forEach(driver => {
            const cardDiv = document.createElement('div');
            cardDiv.classList.add('driver-card');
            cardDiv.style.borderTopColor = `#${driver.teamColor}` || 'E10600';

            const nameHeading = document.createElement('h3');
            nameHeading.classList.add('driver-name');
            nameHeading.textContent = driver.fullName;

            const numberDiv = document.createElement('div');
            numberDiv.classList.add('driver-number');
            numberDiv.textContent = `#${driver.driverNumber}`;

            const teamDiv = document.createElement('div');
            teamDiv.classList.add('driver-team');
            teamDiv.textContent = driver.teamName;

            cardDiv.append(nameHeading, numberDiv, teamDiv);
            driversContainer.append(cardDiv);
        });

    }

const updateDashboard = async() => {
    const sessionKey = sessionInput.value;
    if(!sessionKey) return alert("Please enter a valid session key.");

    teamsContainer.replaceChildren();
    const teamsLoadingMSG = document.createElement('p');
    teamsLoadingMSG.textContent = "Loading layout analytics..."
    teamsContainer.append(teamsLoadingMSG);

    driversContainer.replaceChildren();
    const driversLoadingMSG = document.createElement('p');
    driversLoadingMSG.textContent = "Loading active telemetry...";
    driversContainer.append(driversLoadingMSG);

    try{
        const [driversRes, teamsRes] = await Promise.all([
            fetch(`${API_BASE}/drivers/${sessionKey}`),
            fetch(`${API_BASE}/teams/${sessionKey}`)
        ]);

        const drivers = await driversRes.json();
        const teams = await teamsRes.json();

        renderTeams(teams);
        renderDrivers(drivers);
    }
    catch(error){
        console.error("Box, Box! Dashboard Fetch Error:", error);
        
        teamsContainer.replaceChildren();
        const teamsErrorMSG = document.createElement('p');
        teamsErrorMSG.textContent = "Error loading data.";
        teamsContainer.append(teamsErrorMSG);

        driversContainer.replaceChildren();
        const driversErrorMSG = document.createElement('p');
        driversErrorMSG.textContent = "Error loading data.";
        driversContainer.append(driversErrorMSG);
    }

    
}
loadBtn.addEventListener('click', updateDashboard);
window.addEventListener('DOMContentLoaded', updateDashboard);