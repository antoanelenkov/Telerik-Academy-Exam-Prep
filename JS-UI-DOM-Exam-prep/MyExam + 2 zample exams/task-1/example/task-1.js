function solve(){

    return  function(selector, items) {
        var element = document.querySelector(selector),
        right = document.createElement('div')
        left = document.createElement('div'),
        bigImage = document.createElement('img'),
        heading = document.createElement('strong'),
        filterLabel = document.createElement('label'),
        filterInput = document.createElement('input'),
        imagesCollection = [];


        if (element === null) {
            throw 'invalid element';
        }
        else if (items === undefined) {
            throw 'undefined items'
        }
        else if (!(items instanceof Array)) {
            throw 'items not an array'
        }
        else if (items.length === 0) {
            throw 'empty array'
        }

        //left
        left.style.cssFloat = 'left';

        bigImage.src = items[0].url;
        bigImage.width = 300;
        bigImage.height = 300;
        heading.innerHTML = items[0].title;
        left.className = 'image-preview';

        left.appendChild(heading);
        left.appendChild(bigImage);

        //right
        right.style.cssFloat = 'left';
        right.setAttribute("style", "width:200px; height:300px; padding-left : 20px; text-align: center;");
        right.style.textAlign='center';
        right.style.overflowY = 'scroll';

        filterInput.id = 'input';

        filterLabel.innerText = 'Filter'
        filterLabel.setAttribute('for', 'input');
        filterLabel.style.display = 'block';


        right.appendChild(filterLabel);
        right.appendChild(filterInput);

        for (var i = 0; i < items.length; i++) {
            var littleImageContainer = document.createElement('div');
            littleImageContainer.className = 'image-container';
            var littleHeading = document.createElement('h3');
            littleHeading.innerHTML = items[i].title;

            var img = document.createElement('img');
            img.width = 100;
            img.height = 100;
            img.src = items[i].url;
            img.style.display = 'inline-block';

            littleImageContainer.appendChild(littleHeading);
            littleImageContainer.appendChild(img);

            littleImageContainer.addEventListener('click', function (ev) {
                if (ev.target instanceof HTMLImageElement) {
                    bigImage.src = ev.target.src;
                    heading.innerText = ev.target.previousElementSibling.innerHTML;
                }
                else if (ev.target instanceof HTMLHeadingElement) {
                    heading.innerText = ev.target.innerText;
                    bigImage.src = ev.target.nextElementSibling.src;
                }
                else {
                    heading.innerText = ev.target.firstChild.innerText;
                    bigImage.src = ev.target.lastChild.src;
                }
            });

            littleImageContainer.addEventListener('mouseover', function (ev) {
                if (ev.target instanceof HTMLImageElement) {
                    ev.target.parentElement.style.backgroundColor = 'gray';
                }
                else if (ev.target instanceof HTMLHeadingElement) {
                    ev.target.parentElement.style.backgroundColor = 'gray';
                }
                else {
                    ev.target.style.backgroundColor = 'gray';
                }
            });

            littleImageContainer.addEventListener('mouseout', function (ev) {
                if (ev.target instanceof HTMLImageElement) {
                    ev.target.parentElement.style.backgroundColor = '';
                }
                else if (ev.target instanceof HTMLHeadingElement) {
                    ev.target.parentElement.style.backgroundColor = '';
                }
                else {
                    ev.target.style.backgroundColor = '';
                }
            });

            filterInput.addEventListener('input', function (ev) {
                var input = ev.target.value.toLowerCase();

                for (var i = 2; i < right.children.length; i++) {
                    if (right.children[i].firstChild.innerHTML.toLowerCase().indexOf(input) < 0) {
                        right.children[i].style.display = 'none';
                    }
                    else {
                        right.children[i].style.display = '';
                    }
                }
            });


            right.appendChild(littleImageContainer);
        }

        element.appendChild(left);
        element.appendChild(right);
    }
}
