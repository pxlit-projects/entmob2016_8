package be.pxl.spring.domain;

import java.io.*;
import java.util.*;

import javax.persistence.*;

import org.springframework.data.authentication.UserCredentials;

@Entity
@Table(name="users")
public class User implements Serializable{
	
	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="user_id")
	private String userId;
	
	@Column(name="first_name")
	private String firstName;
	
	@Column(name="last_name")
	private String lastName;
	
	@Column(name="password")
	private String password;
	
	@Column(name="department")
	private String department;
	
	@OneToMany(mappedBy="user_id")
	private Set<Session> sessions = new HashSet<Session>();
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials fbCredentials;
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials twitterCredentials;
	
	@OneToOne(mappedBy="user_id")
	private UserCredentials steamCredentials;

}
