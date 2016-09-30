package be.pxl.spring.domain;

import javax.persistence.*;

import org.springframework.data.authentication.UserCredentials;

import java.io.*;
import java.util.*;

@Entity
@Table(name="users")
public class User implements Serializable {
	
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
	private UserCredentials twitter_credentials;
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials facebook_credentials;
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials steam_credentials;
	
	

}
