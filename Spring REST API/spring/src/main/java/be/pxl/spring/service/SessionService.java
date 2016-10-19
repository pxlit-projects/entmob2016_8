package be.pxl.spring.service;

import java.sql.Timestamp;
import java.util.List;

import be.pxl.spring.domain.Session;


public interface SessionService{
	public abstract Session save(Session session);

	public abstract Session findOne(int Id);

	public abstract List<Session> findByUserId(int userId);

	public abstract List<Session> findByDate(Timestamp timeStamp);

	public abstract List<Session> findByGreaterStartTime(Timestamp timeStamp);

	public abstract List<Session> findByLesserEndTime(Timestamp timeStamp);

	public abstract List<Session> findByGreaterActualTime(int time);

	public abstract List<Session> findByLesserActualTime(int time);

	public abstract void flush();

	public abstract void delete(Session s);
	
}
