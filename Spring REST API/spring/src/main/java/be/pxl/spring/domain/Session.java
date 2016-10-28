package be.pxl.spring.domain;

import java.sql.Timestamp;

import javax.persistence.*;

import org.springframework.stereotype.Component;

@Entity
@Component
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

	public Timestamp getStartTime() {
		return startTime;
	}

	public void setStartTime(Timestamp startTime) {
		this.startTime = startTime;
	}

	public Timestamp getEndTime() {
		return endTime;
	}

	public void setEndTime(Timestamp endTime) {
		this.endTime = endTime;
	}

	public int getActualTime() {
		return actualTime;
	}

	public void setActualTime(int actualTime) {
		this.actualTime = actualTime;
	}

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="session_id")
	private int sessionId;
	
	@Column(name="user_id")
	private int userId;
	
	@Column(name="start_time")
	private Timestamp startTime;
	
	@Column(name="end_time")
	private Timestamp endTime;
	
	@Column(name="actual_time")
	private int actualTime;
}
