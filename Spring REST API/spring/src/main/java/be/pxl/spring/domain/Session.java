package be.pxl.spring.domain;

import java.io.*;
import java.sql.Timestamp;

import javax.persistence.*;

@Entity
@Table(name="sessions")
public class Session {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="session_id")
	private int sessionId;
	
	@ManyToOne
	@JoinColumn(name="user_id")
	private int userId;
	
	@Column(name="start_time")
	private Timestamp start_time;
	
	@Column(name="end_time")
	private Timestamp end_time;
	
	@Column(name="actual_time")
	private Timestamp actual_time;
}
