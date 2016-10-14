package be.pxl.spring.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Embeddable;

@Embeddable
public class CredentialKey implements Serializable {

	@Column(name = "user_id", nullable = false)
	private int userID;
	
	@Column(name = "service", nullable = false)
	private String service;

	public int getUserID() {
		return userID;
	}

	public void setUserID(int userID) {
		this.userID = userID;
	}

	public String getService() {
		return service;
	}

	public void setService(String service) {
		this.service = service;
	}
	
}
