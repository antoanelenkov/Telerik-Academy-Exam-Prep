function createCalendar(selector, events) {
    var container = document.querySelector(selector);
    var fragment = document.createDocumentFragment();
    var days = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];

    var dayElement = document.createElement('div');
    dayElement.style.cssFloat = 'left', dayElement.style.width = '150px', dayElement.style.height = '150px', dayElement.style.border = 'solid';
    var dayHeading = document.createElement('div');
    dayHeading.style.backgroundColor = 'gray';
    var dayInfo = document.createElement('div');
    dayInfo.style.width = '150px', dayInfo.style.height = '130px';

    for (var i = 0; i < 30; i++) {
        var currentDayElement = dayElement.cloneNode();
        var currentDayHeading = dayHeading.cloneNode();
        var currentDayInfo = dayInfo.cloneNode();
        if (i % 7 == 0) {
            currentDayElement.style.clear = 'both';
        }

        currentDayHeading.innerHTML = days[i % 7] + ' ' + (i + 1) + ' ' + 'June 2014';

        for (var j = 0; j < events.length; j++) {
            if (+(events[j].date) === i + 1) {
                currentDayInfo.innerHTML = events[j].hour + ' ' + events[j].title;
            }
        }

        currentDayElement.appendChild(currentDayHeading);
        currentDayElement.appendChild(currentDayInfo);
        fragment.appendChild(currentDayElement);
    }
    container.appendChild(fragment);

    allDays = container.childNodes;

    container.addEventListener('click', function (ev) {
        for (var i = 1; i < allDays.length; i++) {
            allDays[i].style.backgroundColor = '';
        }

        if (ev.target !== container.firstChild) {
            ev.target.parentNode.style.backgroundColor = 'red';
        }
    }, false);

    container.addEventListener('mouseover', function (ev) {
        ev.target.parentNode.firstChild.style.backgroundColor = 'blue';
    }, false);

    container.addEventListener('mouseout', function (ev) {
        ev.target.parentNode.firstChild.style.backgroundColor = 'gray';
    }, false);
}