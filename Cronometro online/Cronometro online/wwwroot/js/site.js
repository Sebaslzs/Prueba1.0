document.addEventListener('DOMContentLoaded', function () {
    function updateElapsedTime() {
        fetch('/Stopwatch/UpdateElapsedTime', {
            method: 'POST'
        })
            .then(response => response.json())
            .then(data => {
                document.getElementById('elapsedTime').innerText = data.elapsedTime;
            });
    }

    setInterval(updateElapsedTime, 1000);
});
