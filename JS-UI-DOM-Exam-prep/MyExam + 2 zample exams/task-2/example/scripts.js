/* globals $ */
$.fn.gallery = function (columns) {
    var columns = columns || 4,
        $container = $(this).first().addClass('gallery'),
        imagesContainer$ = $container.children().first(),
        currentImage = imagesContainer$.children().first(),
        currentBack, previousBack, nextBack,
        currentNext, previousNext, nextNext,
        firstImage = imagesContainer$.children().first();
        lastImage = imagesContainer$.children().last();

    for (var i = 0; i < imagesContainer$.children().length; i += 1) {
        if (i % columns == 0) {
            currentImage.addClass(' clearfix');
        }
        currentImage.on('click', function () {
            $('.selected').css('display', '');
            $('.gallery-list').addClass(' blurred');
            $('.current-image').children().first().attr('src', $(this).children().first().attr('src'));
            if ($(this).prev().children().first().attr('src') !== undefined) {
                $('.previous-image').children().first().attr('src', $(this).prev().children().first().attr('src'));
            }
            else {
                $('.previous-image').children().first().attr('src', imagesContainer$.children().last().children().first().attr('src'));
            }
            if ($(this).next().children().first().attr('src') !== undefined) {
                $('.next-image').children().first().attr('src', $(this).next().children().first().attr('src'));
            }
            else {
                $('.next-image').children().first().attr('src', imagesContainer$.children().first().children().first().attr('src'));
            }

            currentBack = $(this).prev();
            previousBack = $(this).prev().prev();
            nextBack = $(this);

            currentNext = $(this).next();
            nextNext = $(this).next().next();
            previousNext = $(this);
        })
        currentImage = currentImage.next();
    }

    $('.current-image').on('click', function () {
        $('.selected').css('display', 'none');
        $('.gallery-list').removeClass(' blurred');
    });

    $('.previous-image').on('click', function () {

        $('.next-image').children().first().attr('src', nextBack.children().first().attr('src'));
        $('.current-image').children().first().attr('src', currentBack.children().first().attr('src'));
        $('.previous-image').children().first().attr('src', previousBack.children().first().attr('src'));
        if (previousBack.children().first().attr('data-info') === '1') {
            nextBack=currentBack;
            currentBack = previousBack;
            previousBack=lastImage;
        }
        else {
            nextBack = currentBack;
            currentBack = previousBack;
            previousBack = previousBack.prev();
        }
    });

    $('.next-image').on('click', function () {

        $('.next-image').children().first().attr('src', nextNext.children().first().attr('src'));
        $('.current-image').children().first().attr('src', currentNext.children().first().attr('src'));
        $('.previous-image').children().first().attr('src', previousNext.children().first().attr('src'));

        if (nextNext.children().first().attr('data-info') === '12') {
            previousNext = currentNext;
            currentNext = nextNext;
            nextNext = firstImage;
        }
        else {
            previousNext = currentNext;
            currentNext = nextNext;
            nextNext = nextNext.next();
        }
    });

    $('.selected').css('display', 'none');
};