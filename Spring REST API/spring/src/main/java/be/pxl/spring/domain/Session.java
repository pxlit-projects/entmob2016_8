package be.pxl.spring.domain;

import java.io.*;
import java.sql.Timestamp;

import javax.persistence.*;

import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Component;

@Entity
@Table(name="sessions")
public class Session {

	public int getSessionId() {
		return sessionId;
	}

	public void setSessionId(int sessionId) {
		this.sessionId = sessionId;
	}

	public int getUserId() {
		return userId;
	}

	public void setUserId(int userId) {
		this.userId = userId;
	}

	public Timestamp getStart_time() {
		return start_time;
	}

	public void setStart_time(Timestamp start_time) {
		this.start_time = start_time;
	}

	public Timestamp getEnd_time() {
		return end_time;
	}

	public void setEnd_time(Timestamp end_time) {
		this.end_time = end_time;
	}

	public Timestamp getActual_time() {
		return actual_time;
	}

	public void setActual_time(Timestamp actual_time) {
		this.actual_time = actual_time;
	}

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="session_id")
	private int sessionId;
	
	@Column(name="user_id")
	private int userId;
	
	@Column(name="start_time")
	private Timestamp start_time;
	
	@Column(name="end_time")
	private Timestamp end_time;
	
	@Column(name="actual_time")
	private Timestamp actual_time;
}
