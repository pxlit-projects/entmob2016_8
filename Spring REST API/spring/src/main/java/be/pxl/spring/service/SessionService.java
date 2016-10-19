package be.pxl.spring.service;

import java.sql.Timestamp;
import java.util.List;

import javax.persistence.EntityManager;
import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

import be.pxl.spring.domain.Session;
import be.pxl.spring.domain.User;
import be.pxl.spring.repository.SessionRepository;


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
