function solve() {
    return function (selector, isCaseSensitive) {
        var container = document.querySelector(selector);
        container.className += ' items-control';
        var isSensitive = false;

        if (arguments.length === 2 && isCaseSensitive === true) {
            isSensitive = true;
        }

        // result container-------------------------------------------------
        var resultContainer = document.createElement('div');
        resultContainer.className += ' result-controls';
        var resultItems = document.createElement('div');
        resultItems.className += ' items-list';

        resultItems.addEventListener('click', function (ev) {
            if (ev.target.tagName.toLowerCase() === 'button') {
                var containerToDelete = ev.target.parentNode;
                containerToDelete.parentNode.removeChild(containerToDelete);
            }
        }, false);

        resultContainer.appendChild(resultItems);

        // search container-----------------------------------------------
        var searchContainer = document.createElement('div');
        searchContainer.className += ' search-controls';

        var searchLabel = document.createElement('label');
        searchLabel.innerHTML = 'Search:';

        var searchInput = document.createElement('input');

        searchContainer.appendChild(searchLabel);
        searchContainer.appendChild(searchInput);

        searchInput.addEventListener('input', function () {
            var containersToHide;

            if (isSensitive) {
                var inputTextFilter = searchInput.value;

                for (var i = 0; i < resultItems.childNodes.length; i++) {
                    var labelToDelete = resultItems.childNodes[i].lastElementChild.innerHTML;
                    if (labelToDelete.indexOf(inputTextFilter) >= 0) {
                        resultItems.childNodes[i].style.display = '';
                    }
                    else {
                        resultItems.childNodes[i].style.display = 'none';
                    }
                }
            }
            else {
                var inputTextFilter = searchInput.value.toLowerCase();

                for (var i = 0; i < resultItems.childNodes.length; i++) {
                    var labelToDelete = resultItems.childNodes[i].lastElementChild.innerHTML;
                    if (labelToDelete.toLowerCase().indexOf(inputTextFilter) >= 0) {
                        resultItems.childNodes[i].style.display = '';
                    }
                    else {
                        resultItems.childNodes[i].style.display = 'none';
                    }
                }
            }
        }, false);

        // add container-------------------------------------------------
        var addContainer = document.createElement('div');
        addContainer.className += ' add-controls';

        var addLabel = document.createElement('label');
        addLabel.innerHTML = 'Enter text';

        var addInput = document.createElement('input');

        var addButton = document.createElement('button');
        addButton.className += ' button';
        addButton.innerHTML = 'Add';

        addContainer.appendChild(addLabel);
        addContainer.appendChild(addInput);
        addContainer.appendChild(addButton);

        addButton.addEventListener('click', function () {
            var recordContainer = document.createElement('div');
            recordContainer.className += ' list-item';
            var recordText = document.createElement('label');
            recordText.innerHTML = addInput.value;
            var recordButton = document.createElement('button');
            recordButton.innerHTML = 'X';

            recordContainer.appendChild(recordButton);
            recordContainer.appendChild(recordText);

            if (isSensitive) {
                if (recordText.innerHTML.indexOf(searchInput.value) < 0) {
                    recordContainer.style.display = 'none';
                }
            }
            else {
                if (recordText.innerHTML.toLowerCase().indexOf(searchInput.value.toLowerCase()) < 0) {
                    recordContainer.style.display = 'none';
                }
            }


            resultItems.appendChild(recordContainer);
        }, false);

        //------------------------------------------------------------------
        container.appendChild(addContainer);
        container.appendChild(searchContainer);
        container.appendChild(resultContainer);
    };
}

module.exports = solve;