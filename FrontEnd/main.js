async function fetchJobs() {
  const res = await fetch("http://localhost:5150/api/Jobs");
  const jobs = await res.json();
  populateTable(jobs);
  drawMap(jobs);
}

function populateTable(jobs) {
  const tbody = document.querySelector("#jobsTable tbody");
  jobs.forEach(job => {
    const row = document.createElement("tr");
    row.innerHTML = `<td><a href="${job.link}" target="_blank">${job.title}</a></td><td>${job.location}</td>`;
    tbody.appendChild(row);
  });
}


function offsetLatLng(lat, lng, index) {
  const offset = 0.002 * index; 
  return { lat: lat + offset, lng: lng + offset };
}

function drawMap(jobs) {
  const map = new google.maps.Map(document.getElementById("map"), {
    zoom: 2,
    center: { lat: 20, lng: 0 },
  });

  const locationGroups = {};


  jobs.forEach(job => {
    if (job.latitude && job.longitude) {
      const key = `${job.latitude},${job.longitude}`;
      if (!locationGroups[key]) {
        locationGroups[key] = {
          jobs: [],
          lat: job.latitude,
          lng: job.longitude,
          location: job.location
        };
      }
      locationGroups[key].jobs.push(job);
    }
  });

  Object.values(locationGroups).forEach(group => {
    const label = `${group.jobs.length}`;
    new google.maps.Marker({
      position: { lat: group.lat, lng: group.lng },
      map,
      label: {
        text: label,
        color: "white",
        fontSize: "14px",
        fontWeight: "bold"
      },
      icon: {
        path: google.maps.SymbolPath.CIRCLE,
        scale: 20,
        fillColor: "#4285F4",
        fillOpacity: 0.9,
        strokeWeight: 1,
        strokeColor: "#fff"
      },
      title: `${group.jobs.length} jobs in ${group.location}`
    });


    group.jobs.forEach((job, i) => {
      const offset = offsetLatLng(group.lat, group.lng, i + 1);

      const marker = new google.maps.Marker({
        position: offset,
        map,
        title: job.title,
      });

      const infoWindow = new google.maps.InfoWindow({
        content: `<strong>${job.title}</strong><br>${job.location}`,
      });

      marker.addListener("click", () => infoWindow.open(map, marker));
    });
  });
}


fetchJobs();
