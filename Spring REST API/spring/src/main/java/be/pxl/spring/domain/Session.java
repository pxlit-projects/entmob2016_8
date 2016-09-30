package be.pxl.spring.domain;

import java.io.*;
import java.sql.Timestamp;
import java.util.*;

import javax.persistence.*;

public class Session {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="session_id")
	private String sessionId;
	
	@ManyToOne
	@JoinColumn(name = "user_id")
	private String userId;
	
	@Column(name="start_time")
	private Timestamp startTime;
	
	@Column(name="end_time")
	private Timestamp endTime;
	
	@Column(name="actual_time")
	private int voiceTime;
	
}
