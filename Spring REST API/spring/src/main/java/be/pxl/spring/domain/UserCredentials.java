package be.pxl.spring.domain;

import javax.persistence.Column;
import javax.persistence.EmbeddedId;
import javax.persistence.Entity;
import javax.persistence.Table;

@Entity
@Table(name="credentials")
public class UserCredentials {

	@EmbeddedId
	private CredentialKey Credential_PK;
	
	@Column(name="user_name")
	private String UserName;
	
	@Column(name="password")
	private String Password;
	
	public String getUserName() {
		return UserName;
	}
	public void setUserName(String userName) {
		UserName = userName;
	}
	public String getPassword() {
		return Password;
	}
	public void setPassword(String password) {
		Password = password;
	}
}
