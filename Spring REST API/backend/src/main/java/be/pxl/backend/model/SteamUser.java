package be.pxl.backend.model;

public class SteamUser {
	public int UserId;
	public String login, wachtwoord;

	public int getUserId() {
		return UserId;
	}
	public String getLogin() {
		return login;
	}
	public void setLogin(String login) {
		this.login = login;
	}
	public String getWachtwoord() {
		return wachtwoord;
	}
	public void setWachtwoord(String wachtwoord) {
		this.wachtwoord = wachtwoord;
	}
}
