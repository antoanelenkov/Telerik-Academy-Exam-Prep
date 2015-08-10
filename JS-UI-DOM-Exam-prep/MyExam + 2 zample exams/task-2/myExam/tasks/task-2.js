function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        var $this = $(this);



        // you are welcome :)
        var date = new Date();
        console.log(date.getDayName());
        console.log(date.getMonthName());

        var $wrapper = $('div').addClass('datepicker-wrapper');
        var $container = $('<div/>').addClass('picker');
        $this.wrap($wrapper);
        //$wrapper.add($container);
        $container.appendTo($wrapper);
        
        console.log($container)

        console.log($wrapper)
    };
}

module.exports = solve;