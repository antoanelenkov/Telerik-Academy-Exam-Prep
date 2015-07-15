function solve() {
    var audioModule = (function () {
        var playable,
            audio,
            video,
            playlist,
            player,
            validator,
            constants;

        constants = {}

        validator = {
            validateIfUndefined: function (value, message) {
                if (value === undefined) {
                    throw Error('undefined ' + message);
                }
            },
            validateIfType: function (value, type, message) {
                if (typeof value !== type) {
                    throw Error('not ' + type + ' ' + message);
                }
            },
            validateStringLength: function (value, message) {
                if (value.length < 3 || value.length > 25) {
                    throw Error('wrong length ' + message);
                }
            },
            validateAudioLength: function (value) {
                if (value <= 0) {
                    throw Error('wrong audio length ');
                }
            },
            validateImdbRating: function (value) {
                if (value < 1 || value > 5) {
                    throw Error('wrong ImdbRating ');
                }
            },
            validateId: function (value) {
                if (value < 1) {
                    throw Error('invalid ID');
                }
            },
            validatePaging: function (value) {
                if (value < 0) {
                    throw Error('invalid ID');
                }
            },
            validatePlayable: function (value) {


                validator.validateIfUndefined(value.name, 'validatePlayable title');
                validator.validateIfType(value.name, 'string', 'validatePlayable title');
                validator.validateStringLength(value.name);

                //validator.validateIfUndefined(value.author, 'validatePlayable author');
                //validator.validateIfType(value.author, 'string', 'validatePlayable author');
                //validator.validateStringLength(value.author);

                validator.validateIfUndefined(value.id, 'validatePlayable id');
                validator.validateIfType(value.id, 'number', 'validatePlayable id');
                validator.validateId(value.id);

                if (value.length !== undefined && value.imdbRating === undefined) {
                    validator.validateIfType(value.length, 'number', 'validatePlayable length');
                    validator.validateAudioLength(value.length);

                    return 'audio'
                }

                if (value.length === undefined && value.imdbRating !== undefined) {
                    validator.validateIfType(value.imdbRating, 'number', 'validatePlayable length');
                    validator.validateImdbRating(value.imdbRating);

                    return 'video'
                }

                return 'playable';
            }
        }

        playable = (function () {
            var idGenerator = 0,
                playable = Object.create({});

            playable = {
                init: function (title, author) {
                    this.title = title;
                    this.author = author;
                    this.id = ++idGenerator;

                    return this;
                },
                play: function () {
                    return this.id + '. ' + this.title + ' - ' + this.author;
                }
            }

            Object.defineProperties(playable, {
                'title': {
                    get: function () {
                        return this._title;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'playable title');
                        validator.validateIfType(value, 'string', 'playable title');
                        validator.validateStringLength(value);
                        this._title = value;
                    }
                },
                'author': {
                    get: function () {
                        return this._author;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'playable author');
                        validator.validateIfType(value, 'string', 'playable author');
                        validator.validateStringLength(value);
                        this._author = value;
                    }
                }
            })

            return playable;
        }());

        audio = (function (parent) {
            var audio = Object.create(parent);

            audio.init = function (title, author, length) {
                parent.init.call(this, title, author);
                this.length = length;

                return this;
            };

            audio.play = function () {
                return parent.play.call(this) + ' - ' + this.length;
            }

            Object.defineProperties(audio, {
                'length': {
                    get: function () {
                        return this._length;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'audio length');
                        validator.validateIfType(value, 'number', 'audio length');
                        validator.validateAudioLength(value);

                        this._length = value;
                    }
                }
            })

            return audio;
        }(playable));

        video = (function (parent) {
            var video = Object.create(parent);

            video.init = function (title, author, imdbRating) {
                parent.init.call(this, title, author);
                this.imdbRating = imdbRating;

                return this;
            };

            video.play = function () {
                return parent.play.call(this) + ' - ' + this.imdbRating;
            }

            Object.defineProperties(video, {
                'imdbRating': {
                    get: function () {
                        return this._imdbRating;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'video imbd');
                        validator.validateIfType(value, 'number', 'video imbd');
                        validator.validateImdbRating(value);

                        this._imdbRating = value;
                    }
                }
            })

            return video;
        }(playable));


        //---------------------------PLAYLIST-----------------------------------------


        playlist = (function () {
            var idGenerator = 0,
                playlist = Object.create({});

            playlist.init = function (name) {
                this.name = name;
                this.id = ++idGenerator;
                this.playables = [];

                return this;
            }

            playlist.addPlayable = function (playable) {
                var playableToAdd = Object.create(playable),
                    typeOfPlayable;

                validator.validateIfUndefined(playable, 'add playable');
                validator.validateIfType(playable, 'object', 'add playable');
                typeOfPlayable = validator.validatePlayable(playable);

                playableToAdd.title = playable.name;
                playableToAdd.author = playable.author;
                playableToAdd.id = playable.id;

                if (typeOfPlayable === 'audio') {
                    playableToAdd.length = playable.length;
                }
                else if (typeOfPlayable === 'video') {
                    playableToAdd.imdbRating = playable.imdbRating;
                }

                this.playables.push(playableToAdd);

                return this;
            }

            playlist.getPlayableById = function (id) {
                validator.validateIfUndefined(id);
                validator.validateIfType(id,'number','getPlayableById')
                validator.validateId(id);
                var i;

                for (i = 0; i < this.playables.length; i += 1) {
                    if (this.playables[i].id === id) {
                        return this.playables[i];
                    }
                }

                return null;
            }

            playlist.removePlayable = function (arg) {
                var i;

                validator.validateIfUndefined(arg);
                if (typeof arg === 'number') {
                    for (i = 0; i < this.playables.length; i += 1) {
                        if (this.playables[i].id === arg) {
                            this.playables.splice(i, 1);

                            return this;
                        }
                    }

                    throw  Error('there is no playable with this ID');
                }
                else if (typeof arg === 'object') {

                    for (i = 0; i < this.playables.length; i += 1) {
                        if (this.playables[i].id === arg.id) {
                            this.playables.splice(i, 1);

                            return this;
                        }
                    }

                    throw  Error('there is no playable like this one');
                }

                throw Error('wrong object or id for deleting');
            }

            function mySort(array) {
                return array.sort(function (a, b) {
                    if (a.title > b.title) {
                        return 1;
                    }
                    else if (a.title < b.title) {
                        return -1;
                    }

                    if (a.id > b.id) {
                        return 1;
                    }
                    else {
                        return -1;
                    }
                })
            }

            playlist.listPlayables = function (page, size) {
                validator.validateIfUndefined(page, 'undefined page');
                validator.validateIfType(page, 'number');
                validator.validatePaging(page, 'not a number page');
                validator.validateIfUndefined(size, 'undefined size');
                validator.validateIfType(size, 'number');
                validator.validateId(size, 'not a number size');


                this.playables = mySort(this.playables);

                if (page * size > this.playables.length) {
                    throw Error('paging out of range');
                }


                return this.playables.slice().splice(size * page, size);
            }

            Object.defineProperties(playlist, {
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'playlist name');
                        validator.validateIfType(value, 'string', 'playlist name');
                        validator.validateStringLength(value, 'playlist name');

                        this._name = value;
                    }
                }
            })

            return playlist;
        }());


        //-------------------------------------PLAYER--------------------------//

        player = (function () {
            var idGenerator = 0,
                player = Object.create({});

            player.init = function (name) {
                this.name = name;
                this.id = ++idGenerator;
                this.playLists = [];

                return this;
            }

            player.getPlayer = function (name) {
                return Object.create(player).init(name);
            }

            player.addPlaylist = function (playList) {
                validator.validateIfUndefined(playList);

                if (!playlist.isPrototypeOf(playList)) {
                    throw new Error('is not instance of playlist')
                }

                this.playLists.push(playList);

                return this;
            }

            player.getPlaylistById = function (id) {
                validator.validateIfUndefined(id);

                for (var i = 0; i < this.playLists.length; i += 1) {
                    if (this.playLists[i].id === id) {
                        return this.playLists[i];
                    }
                }

                return null;
            }

            player.removePlaylist = function (arg) {
                var i;

                validator.validateIfUndefined(arg);
                if (typeof arg === 'number') {
                    for (i = 0; i < this.playLists.length; i += 1) {
                        if (this.playLists[i].id === arg) {
                            this.playLists.splice(i, 1);

                            return this;
                        }
                    }

                    throw  Error('there is no playLists with this ID');
                }
                else if (typeof arg === 'object') {

                    for (i = 0; i < this.playLists.length; i += 1) {
                        if (this.playLists[i].id === arg.id) {
                            this.playLists.splice(i, 1);

                            return this;
                        }
                    }

                    throw  Error('there is no playLists  like this one');
                }

                throw Error('wrong object or id for deleting');
            }

            player.listPlaylists = function (page, size) {
                validator.validateIfUndefined(page, 'undefined page');
                validator.validateIfType(page, 'number');
                validator.validatePaging(page, 'not a number page');
                validator.validateIfUndefined(size, 'undefined size');
                validator.validateIfType(size, 'number');
                validator.validateId(size, 'not a number size');


                this.playLists = mySort(this.playLists);

                if (page * size > this.playLists.length) {
                    throw Error('paging out of range');
                }


                return this.playLists.slice().splice(size * page, size);
            }

            player.contains = function (playable, playlist) {
                validator.validateIfUndefined(playable, 'undefined playable');
                validator.validateIfType(playable, 'object');

                validator.validateIfUndefined(playlist, 'undefined playList');
                validator.validateIfType(playlist, 'object');

                return this.playLists.some(function (item) {
                    return item.id === playable.id;
                });
            }


            player.search = function (pattern) {
                validator.validateIfUndefined(pattern, 'pattern');
                validator.validateIfType(pattern, 'string');
                validator.validateStringLength(pattern);

                return this.playLists.filter(function (playlist) {
                    return playlist.listPlaylables(0, 100000000000).some(function (song) {
                        return song.length !== undefined && song
                                .title
                                .toLowerCase()
                                .indexOf(pattern.toLowerCase()) >= 0;
                    });
                }).map(function (playlist) {
                    return {
                        id: playlist.id,
                        name: playlist.name
                    }
                });
            }

            Object.defineProperties(player, {
                name: {
                    get: function () {
                        return this._name;
                    },
                    set: function (value) {
                        validator.validateIfUndefined(value, 'player name');
                        validator.validateIfType(value, 'string', 'player name');
                        validator.validateStringLength(value, 'player name');

                        this._name = value;
                    }
                }
            })

            return player;
        }
        ()
        )
        ;

        return {
            getPlayer: function (name) {
                return Object.create(player).init(name);
            },
            getPlaylist: function (name) {
                return Object.create(playlist).init(name);
            },
            getAudio: function (title, author, length) {
                return Object.create(audio).init(title, author, length);
            },
            getVideo: function (title, author, imdbRating) {
                return Object.create(video).init(title, author, imdbRating);
            },
            getPlayable: function (title, author) {
                return Object.create(playable).init(title, author);
            }
        };
    }
    ()
    )

    return audioModule;
}
