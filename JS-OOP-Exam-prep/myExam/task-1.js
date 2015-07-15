function solve() {
    var catalogModule = (function () {
        var item,
            book,
            media,
            catalog,
            bookCatalog,
            mediaCatalog,
            validator,
            constants;

        constants = {}

        validator = {
            validateIfUndefined: function
                (value, message) {
                if (value === undefined) {
                    throw Error('undefined ' + message);
                }
            }
            ,
            validateIfType: function (value, type, message) {
                if (typeof value !== type) {
                    throw Error('not ' + type + ' ' + message);
                }
            }
            ,
            validateStringLength: function (value, message) {
                if (value.length < 3 || value.length > 25) {
                    throw Error('wrong length ' + message);
                }
            }
            ,
            validateId: function (value) {
                if (value < 1) {
                    throw Error('invalid ID');
                }
            }
            ,
            validateItem: function (value) {
                validator.validateIfUndefined(value.description, 'validateItem desc');
                validator.validateIfType(value.description, 'string', 'validateItem desc');
                if (value.description.length === 0) {
                    throw new Error('empty string item description');
                }

                validator.validateIfUndefined(value.name, 'validateItem name');
                validator.validateIfType(value.name, 'string', 'validateItem name');
                if (value.name.length < 2 || value.name.length > 40) {
                    throw new Error('empty string validateItem name');
                }

                validator.validateIfUndefined(value.id, 'validateItem id');
                validator.validateIfType(value.id, 'number', 'validateItem id');
                validator.validateId(value.id);

            },
            validateBook: function (value) {
                if (value.isbn !== undefined && value.genre !== undefined) {
                    validator.validateIfUndefined(value.isbn, 'validateItem name');
                    validator.validateIfType(value.isbn, 'string', 'validateItem name');
                    if (!(/^\d+$/.test(value.isbn))) {
                        throw new Error('isbn contains not only digits');
                    }
                    if (value.isbn.length !== 10 && value.isbn.length !== 13) {
                        throw new Error('invalid length of isbn')
                    }

                    validator.validateIfUndefined(value.genre, 'book description');
                    validator.validateIfType(value.genre, 'string', 'book description');
                    if (value.genre.length < 2 || value.genre.length > 20) {
                        throw new Error('invalid length of genre')
                    }
                }

            },
            validateMedia: function (value) {
                if (value.duration !== undefined && value.rating !== undefined) {
                    validator.validateIfUndefined(value.duration, 'validateItem name');
                    validator.validateIfType(value.duration, 'number', 'validateItem name');
                    if (value.duration < 0) {
                        throw new Error('invalid length of duration')
                    }

                    validator.validateIfUndefined(value.rating, 'book description');
                    validator.validateIfType(value.rating, 'number', 'book description');
                    if (value.rating < 1 || value.rating > 5) {
                        throw new Error('invalid length of rating')
                    }
                }

            }
        }


        //--------------------interface---------------------------------and simple classes-----------------

        //-----------------------ITEM----------------------

        item = (function () {
            var idGenerator = 0,
                item = Object.create({});

            item = {
                init: function (name, description) {
                    this.id = ++idGenerator;
                    this.name = name;
                    this.description = description;

                    return this;
                }
            }

            Object.defineProperties(item, {
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'item name');
                        validator.validateIfType(value, 'string', 'item name');
                        if (value.length < 2 || value.length > 40) {
                            throw new Error('empty string item name');
                        }
                        this._name = value;
                    }
                },
                description: {
                    get: function () {
                        return this._description;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'item description');
                        validator.validateIfType(value, 'string', 'item description');
                        if (value.length === 0) {
                            throw new Error('empty string item description');
                        }
                        this._description = value;
                    }
                }
            })

            return item;
        }());

        //---------------------------BOOK-------------------------

        book = (function (parent) {
            var book = Object.create(parent);

            book.init = function (name, isbn, genre, description) {
                parent.init.call(this, name, description);
                this.isbn = isbn;
                this.genre = genre;

                return this;
            };

            Object.defineProperties(book, {
                isbn: {
                    get: function () {
                        return this._isbn;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'book description');
                        validator.validateIfType(value, 'string', 'book description');
                        if (!(/^\d+$/.test(value))) {
                            throw new Error('isbn contains not only digits');
                        }
                        if (value.length !== 10 && value.length !== 13) {
                            throw new Error('invalid length of isbn')
                        }
                        this._isbn = value;
                    }
                },
                genre: {
                    get: function () {
                        return this._genre;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'book description');
                        validator.validateIfType(value, 'string', 'book description');
                        if (value.length < 2 || value.length > 20) {
                            throw new Error('invalid length of genre')
                        }
                        this._genre = value;
                    }
                }
            })

            return book;
        }(item));

        //---------------------------MEDIA----------------------------

        media = (function (parent) {
            var media = Object.create(parent);

            media.init = function (name, rating, duration, description) {
                parent.init.call(this, name, description);
                this.duration = duration;
                this.rating = rating;

                return this;
            };

            Object.defineProperties(media, {
                duration: {
                    get: function () {
                        return this._duration;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'media duration');
                        validator.validateIfType(value, 'number', 'media duration');
                        if (value < 0) {
                            throw new Error('media duration must be greater than 0');
                        }

                        this._duration = value;
                    }
                },
                rating: {
                    get: function () {
                        return this._rating;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'media rating');
                        validator.validateIfType(value, 'number', 'media rating');
                        if ((value.length < 1 || value.length > 5)) {
                            throw new Error('invalid length of rating')
                        }
                        this._rating = value;
                    }
                }
            })

            return media;
        }(item));


        //---------------------------CATALOG-----------------------------------------


        catalog = (function () {
            var idGenerator = 0,
                catalog = Object.create({});

            catalog.init = function (name) {
                this.name = name;
                this.id = ++idGenerator;
                this._items = [];

                return this;
            }

            catalog.add = function (array) {
                var args = arguments.length;

                if (args === 0) {
                    throw Error('zero arguments when adding to catalog');
                }

                if (!(Object.prototype.toString.call(arguments[0]) === '[object Array]')) {
                    for (var i = 0; i < args; i += 1) {
                        validator.validateIfUndefined(arguments[i], 'add playable');
                        validator.validateIfType(arguments[i], 'object', 'add playable');
                        validator.validateItem(arguments[i]);
                    }

                    for (var i = 0; i < args; i += 1) {
                        this.items.push(arguments[i]);
                    }

                    return 'objects';
                }
                else {
                    validator.validateIfUndefined(array, 'add array');
                    validator.validateIfType(array, 'object', 'add array');
                    if (array.length === 0) {
                        throw Error('zero array length');
                    }
                    for (var i = 0; i < array.length; i += 1) {
                        validator.validateIfUndefined(array[i], ' array');
                        validator.validateIfType(array[i], 'object', 'array');
                        validator.validateItem(array[i]);
                    }

                    for (var i = 0; i < array.length; i += 1) {
                        this.items.push(array[i]);
                    }

                    return 'array';
                }
            }


            catalog.find = function (options) {
                validator.validateIfUndefined(options);

                if (typeof options === 'number') {
                    validator.validateIfUndefined(options);
                    validator.validateIfType(options, 'number')
                    validator.validateId(options);

                    for (var i = 0; i < this.items.length; i += 1) {
                        if (this.items[i].id === options) {
                            return this.items[i];
                        }
                    }

                    return null;
                }
                else {
                    var result = [];

                    for (var i = 0; i < this.items.length; i += 1) {
                        if (options.id !== undefined && options.name !== undefined) {
                            if (this.items[i].id === options.id && this.items[i].name === options.name) {
                                result.push(this.items[i]);
                            }
                        }
                        else if (options.id !== undefined) {
                            if (this.items[i].id === options.id) {
                                result.push(this.items[i]);
                            }
                        }
                        else if (options.name !== undefined) {
                            if (this.items[i].name === options.name) {
                                result.push(this.items[i]);
                            }
                        }
                    }

                    return result;
                }
            }

            catalog.search = function (pattern) {
                validator.validateIfUndefined(pattern, 'pattern');
                validator.validateIfType(pattern, 'string');
                if (pattern.length < 1) {
                    throw 'small pattern';
                }

                return this.items.filter(function (item) {
                    return ((item.name.toLowerCase().indexOf(pattern.toLowerCase()) >= 0)
                    || (item.description.toLowerCase().indexOf(pattern.toLowerCase()) >= 0))
                });
            }

            Object.defineProperties(catalog, {
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'catalog name');
                        validator.validateIfType(value, 'string', 'catalog name');
                        if (value.length < 2 || value.length > 40) {
                            throw new Error('Value of catalog name')
                        }

                        this._name = value;
                    }
                },
                items: {
                    get: function () {
                        return this._items;
                    },
                    set: function (value) {
                        this._items = value;
                    }

                }
            })

            return catalog;
        }());


        //-------------------------------------BOOKCATALOG--------------------------//

        bookCatalog = (function (parent) {
            var bookCatalog = Object.create(parent);

            bookCatalog.init = function (name) {
                parent.init.call(this, name);

                return this;
            }

            bookCatalog.add = function (array) {
                var args = arguments.length;
                var result = parent.add.call(this, array);

                if (result === 'object') {
                    for (var i = 0; i < args; i += 1) {
                        validator.validateIfUndefined(arguments[i], 'add playable');
                        validator.validateIfType(arguments[i], 'object', 'add playable');
                        validator.validateBook(arguments[i]);

                    }

                    for (var i = 0; i < args; i += 1) {
                        this.items.push(arguments[i]);
                    }
                } else {
                    for (var i = 0; i < array.length; i += 1) {
                        validator.validateIfUndefined(array[i], ' array');
                        validator.validateIfType(array[i], 'object', 'array');
                        validator.validateBook(array[i]);
                        parent.add(array[i]);
                    }

                    for (var i = 0; i < array.length; i += 1) {
                        this.items.push(array[i]);
                    }
                }

                return this;
            }

            bookCatalog.getGenres = function () {
                var result = [];

                for (var i = 0; i < this.items.length; i += 1) {
                    var included=false;
                    for(var j=0;j<result.length;j++){
                        console.log(this.items[i].genre);
                        if( (result[j].toLowerCase())=== (this.items[i].genre.toLowerCase())){
                            included=true;
                        }
                    }
                    if(included===false){
                        result.push(this.items[i].genre.toLowerCase());
                    }
                }

                return result;
            }

            bookCatalog.find = function (options) {
                var i;
                var result = parent.find.call(this, options);
                if (result.length === 0) {
                    for (i = 0; i < this.items.length; i += 1) {
                        if (options.id !== undefined && options.name !== undefined && options.genre !== undefined) {
                            if (this.items[i].id === options.id && this.items[i].name === options.name && this.items[i].genre === options.genre) {
                                result.push(this.items[i]);
                            }
                        }
                        else if (options.genre !== undefined) {
                            if (this.items[i].genre === options.genre) {
                                result.push(this.items[i]);
                            }
                        }
                    }
                }

                return result;
            }

            return bookCatalog;
        }
        (catalog)
        )
        ;

        //------------------------------------MEDIA CATALOG------------------------

        mediaCatalog = (function (parent) {
            var mediaCatalog = Object.create(parent);

            mediaCatalog.init = function (name) {
                parent.init.call(this, name);

                return this;
            }

            mediaCatalog.add = function (array) {
                var args = arguments.length;
                var result = parent.add.call(this, array);

                if (result === 'object') {
                    for (var i = 0; i < args; i += 1) {
                        validator.validateIfUndefined(arguments[i], 'add playable');
                        validator.validateIfType(arguments[i], 'object', 'add playable');
                        validator.validateMedia(arguments[i]);
                    }

                    for (var i = 0; i < args; i += 1) {
                        this.items.push(arguments[i]);
                    }
                } else {
                    for (var i = 0; i < array.length; i += 1) {
                        validator.validateIfUndefined(array[i], ' array');
                        validator.validateIfType(array[i], 'object', 'array');
                        validator.validateMedia(array[i]);
                    }

                    for (var i = 0; i < array.length; i += 1) {
                        this.items.push(array[i]);
                    }
                }

                return this;
            }

            function sortByRating(array) {
                return array.sort(function (a, b) {
                    if (a.rating < b.rating) {
                        return 1;
                    }
                    else if (a.rating >= b.rating) {
                        return -1;
                    }
                })
            }

            mediaCatalog.getTop = function (count) {
                validator.validateIfUndefined(count);
                validator.validateIfType(count, 'number');
                if (count < 1) {
                    throw new Error('count less than 1');
                }

                var result = [];

                for (var i = 0; i < this.items.length; i += 1) {
                    if (this.items[i].rating !== undefined) {
                        result.push(this.items[i]);
                    }
                }

                return sortByRating(result).slice().splice(0, count);
            }

            return mediaCatalog;
        }
        (catalog)
        )
        ;


        return {
            getBook: function (name, isbn, genre, description) {
                return Object.create(book).init(name, isbn, genre, description);
            },
            getMedia: function (name, rating, duration, description) {
                return Object.create(media).init(name, rating, duration, description);
            },
            getBookCatalog: function (name) {
                return Object.create(bookCatalog).init(name);
            },
            getMediaCatalog: function (name) {
                return Object.create(mediaCatalog).init(name);
            }
        };
    }
    ()
    )

    return catalogModule;
}

var module = solve();

var catalog = module.getBookCatalog('John\'s catalog');

var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
var book3 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT2', 'A good book about JS');
catalog.add(book1);
catalog.add(book2);
catalog.add(book3);

//console.log(catalog.find(book1.id));
//returns book1

//console.log(catalog.find({id: book2.id, genre: 'IT'}));
//returns book2

//console.log(catalog.search('js'));
// returns book2

//console.log(catalog.search('javascript'));
//returns book1 and book2

//console.log(catalog.search('Te sa zeleni'))
//returns []

console.log(catalog.getGenres());

var mediaCatalog = module.getMediaCatalog('Media catalog');

var media1 = module.getMedia('bounce', 4, 3.43, "song");
var media2 = module.getMedia('scary movie', 3, 90.43, "movie");
var media2 = module.getMedia('scary movie',2, 90.43, "movie");
var media2 = module.getMedia('scary movie', 1, 90.43, "movie");
mediaCatalog.add(media1);
mediaCatalog.add(media2);
mediaCatalog.add([media1, media2]);

console.log(mediaCatalog.getTop(2));


