package be.pxl.spring.domain;

import javax.persistence.*;


import org.springframework.stereotype.Component;

import java.io.*;
import java.util.*;

@Entity
@Table(name="users")
@Component
public class User implements Serializable {
	public User()
	{
		
	}
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
	
	public String getSalt() {
		return salt;
	}
	
	public void setSalt(String salt) {
		this.salt = salt;
	}
	
	public String getRole() {
		return role;
	}
	
	public void setRole(String role) {
		this.role = role;
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
	
	@Column(name="salt")
	private String salt;

	@Column(name="department")
	private String department;
	
	@Column(name="role")
	private String role;
	

	@OneToMany(targetEntity=Session.class, mappedBy="userId", fetch = FetchType.LAZY)	
	private Set<Session> sessions;
	
	

}
