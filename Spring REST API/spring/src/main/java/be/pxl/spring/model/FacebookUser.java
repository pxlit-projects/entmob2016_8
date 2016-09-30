package be.pxl.spring.model;

public class FacebookUser {

	int userId;
	String login, password;
	
	public int getUserId() {
		return userId;
	}
	public String getLogin() {
		return login;
	}
	public void setLogin(String login) {
		this.login = login;
	}
	public String getPassword() {
		return password;
	}
	public void setPassword(String password) {
		this.password = password;
	}
	
	
}
