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
