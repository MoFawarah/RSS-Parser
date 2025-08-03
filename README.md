
Project Name: RssJobParserApi

Language: C#
Backend: .net Core API
FrontEnd: HTML, CSS, JS

Description:
This project fetches job openings from an RSS feed and displays them on a map using Google Maps JavaScrips API and Geocoding API.

Steps to Run the Program:
1. Clone the repository from [https://github.com/MoFawarah/RSS-Parser.git].
2. Open the solution in Visual Studio.
3. Build the solution to restore NuGet packages.
4. Run the project.
5. Open the Front End app while the backend is running to see the results.

Video Link:
[https://drive.google.com/file/d/1rMDLPY8r1jbgGFvsajsgx0Az1ckvh3lv/view?usp=sharing]


///////////////// OPTIONAL STEPS //////////////

OPTIONAL: if you need to run the project using your own api key for google services, follow these steps:
You need a Google Cloud Platform account with billing enabled

Setup Instructions
1. Clone the repository.
2. Navigate to the project directory.
3. Replace YOUR_GOOGLE_MAPS_API_KEY in appsettings.json with your own Google Maps API key.
"GoogleMaps": {
    "ApiKey": "YOUR_GOOGLE_MAPS_API_KEY" 
},

4. Enable APIs: You need to enable these APIS from your google console account
 a. Maps JavaScript API: Enables embedding Google Maps on web pages.
 b. Geocoding API: Converts addresses into geographic coordinates and vice versa.

5. In the frontend index.html, replace "YOUR_GOOGLE_MAPS_API_KEY" in <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_GOOGLE_MAPS_API_KEY"></script> with the same API KEY used in the backend.

 ///////////////// OPTIONAL STEPS //////////////

