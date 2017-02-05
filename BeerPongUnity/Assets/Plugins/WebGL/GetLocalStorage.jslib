var GetLocalStoragePlugin = {
	GetIdToken: function()
	{
		var token = localStorage.getItem("id_token");
		if (token === null) {
			token = "undefined";
		}
		var buffer = _malloc(lengthBytesUTF8(token) + 1);
        writeStringToMemory(token, buffer);
		return (buffer);
	},
	GetIdGame: function()
	{
		var token = localStorage.getItem("game_ref");
		if (token === null) {
			token = "undefined";
		}
		var buffer = _malloc(lengthBytesUTF8(token) + 1);
        writeStringToMemory(token, buffer);
		return (buffer);
	},
	RedirectToHome: function()
	{
		window.location.href = 'http://playarshop.com/game/recap';
	}
};

mergeInto(LibraryManager.library, GetLocalStoragePlugin);