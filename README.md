# 🏎️ F1 Race Control Dashboard
A full-stack telemetry and race analytics suite built to bridge the gap between raw race data and fan-friendly visualizations. 

## 🎯 Project Overview
This project serves as a comprehensive learning exercise for my 4th semester, focusing on **Full-Stack Engineering**, **Data Processing in C#**, and **Asynchronous UI Management**. The goal is to ingest real-time and historical data from the OpenF1 API and present it through a high-performance "Race Control" interface.

## 🛠️ Tech Stack
* **Backend:** C# / .NET 8 Web API (Data orchestration & caching)
* **Frontend:** HTML5, CSS3 (Grid/Flexbox), Vanilla JavaScript
* **Data Vis:** Chart.js (Telemetry & Lap-time analysis)
* **External API:** [OpenF1 API](https://openf1.org/)

---

## 📈 6-Week Development Roadmap (1 Hour/Day)

### Phase 1: Foundation & API Connectivity (Week 1)
* **Objective:** Establish the bridge between the server and the data source.
* **Tasks:**
    * [x] Initialize .NET Web API project and local Git repository.
    * [x] Configure `HttpClient` factory in C# to consume OpenF1 endpoints.
    * [x] Create basic JSON-to-C# DTOs (Data Transfer Objects) for Driver and Session data.
    * [x] **Milestone:** A console log or basic HTML list showing real-time driver names fetched via the C# backend.

### Phase 2: Backend Logic & Secure Architecture (Week 2)
* **Objective:** Implement secure coding practices and data filtering.
* **Tasks:**
    * [x] Implement an **Abstraction Layer**: The frontend should never call OpenF1 directly; it calls *my* API.
    * [x] **Secure Coding:** Move API base URLs and sensitive configurations to `appsettings.json`.
    * [x] **Data Transformation:** Write C# logic to calculate gaps between drivers or average lap times before sending data to the UI.
    * [x] **Milestone:** Functional API endpoints (e.g., `/api/race/standings`) returning cleaned, optimized data.

### Phase 3: The "Race Control" UI (Week 3)
* **Objective:** Build a responsive, high-fidelity dashboard.
* **Tasks:**
    * [ ] Design a "Dark Mode" theme using CSS variables (F1 Red: `#E10600`).
    * [ ] Implement **CSS Grid** for the dashboard layout (Sidebar for standings, Main stage for telemetry).
    * [ ] Use **Flexbox** for dynamic driver cards that scale across mobile/desktop.
    * [ ] **Milestone:** A visually polished static dashboard populated with real data.

### Phase 4: Dynamic Interactions & State (Week 4)
* **Objective:** Enhance the user experience with JavaScript.
* **Tasks:**
    * [ ] Implement a "Search/Filter" bar to highlight specific drivers.
    * [ ] Use `localStorage` to save a user's "Favorite Team," updating the UI theme automatically.
    * [ ] Handle loading states and "No Data" errors gracefully using JS Promises.
    * [ ] **Milestone:** A dashboard that remembers user preferences and responds to user input without page refreshes.

### Phase 5: Telemetry Visualization (Week 5)
* **Objective:** Integrate Chart.js for data storytelling.
* **Tasks:**
    * [ ] Fetch lap-by-lap data for two drivers.
    * [ ] Configure a **Chart.js** line graph to compare speed or lap consistency.
    * [ ] Implement "Interactive Legends" to toggle data visibility on the fly.
    * [ ] **Milestone:** A professional-grade telemetry chart that visualizes the "battle" on track.

### Phase 6: Optimization & Caching (Week 6)
* **Objective:** Finalize for deployment.
* **Tasks:**
    * [ ] **Performance:** Add `IMemoryCache` to the C# backend to prevent redundant API calls to OpenF1.
    * [ ] **Code Review:** Refactor according to TA-level standards (DRY principles, proper naming conventions).
    * [ ] **Documentation:** Finalize README and project screenshots.
    * [ ] **Milestone:** Project deployed/hosted and ready for inclusion in a professional portfolio.

---

## 🛡️ Secure Coding Implementation
As a TA for Secure Coding, I am prioritizing:
1.  **Input Validation:** Sanitizing all query parameters (Driver IDs, Session IDs) in the C# controllers.
2.  **Information Exposure:** Ensuring detailed stack traces are disabled in production.
3.  **Dependency Management:** Regularly checking for vulnerabilities in NuGet and NPM packages.

---

## 🚀 How to Run (Development)
1. Clone the repo: `git clone [your-repo-url]`
2. Navigate to `/Backend` and run `dotnet run`.
3. Open `/Frontend/index.html` in a browser (or use Live Server).