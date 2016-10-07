package be.pxl.spring.domain;

import javax.persistence.*;

import org.springframework.context.annotation.Scope;
import org.springframework.data.authentication.UserCredentials;
import org.springframework.stereotype.Component;

import java.io.*;
import java.util.*;

@Entity
@Table(name="users")
@Component
@Scope("prototype")
public class User implements Serializable {
	
	public int getUserId() {
		return userId;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getDepartment() {
		return department;
	}

	public void setDepartment(String department) {
		this.department = department;
	}

	public Set<Session> getSessions() {
		return sessions;
	}

	public void setSessions(Set<Session> sessions) {
		this.sessions = sessions;
	}

	public UserCredentials getTwitterCredentials() {
		return twitterCredentials;
	}

	public void setTwitterCredentials(UserCredentials twitterCredentials) {
		this.twitterCredentials = twitterCredentials;
	}

	public UserCredentials getFacebookCredentials() {
		return facebookCredentials;
	}

	public void setFacebookCredentials(UserCredentials facebookCredentials) {
		this.facebookCredentials = facebookCredentials;
	}

	public UserCredentials getSteamCredentials() {
		return steamCredentials;
	}

	public void setSteamCredentials(UserCredentials steamCredentials) {
		this.steamCredentials = steamCredentials;
	}

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="user_id")
	private int userId;
	
	@Column(name="first_name")
	private String firstName;
	
	@Column(name="last_name")
	private String lastName;
	
	@Column(name="password")
	private String password;
	
	@Column(name="department")
	private String department;
	
	@OneToMany(mappedBy="session_id")
	private Set<Session> sessions = new HashSet<Session>();
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials twitterCredentials;
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials facebookCredentials;
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials steamCredentials;
	
	

}
