package be.pxl.spring.service;

import java.sql.Timestamp;
import java.util.List;

import javax.transaction.Transactional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import be.pxl.spring.domain.Session;
import be.pxl.spring.repository.SessionRepository;

@Service
@Transactional
public class SessionServiceImpl implements SessionService{
	@Autowired
	private SessionRepository sessionRepo;

	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#save(be.pxl.spring.domain.Session)
	 */
	@Override
	@Transactional
	public Session save(Session session)
	{
		return sessionRepo.save(session);
	}
	
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findOne(int)
	 */
	@Override
	@Transactional
	public Session findOne(int Id)
	{
		return sessionRepo.findOne(Id);
	}
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findByUserId(int)
	 */
	@Override
	@Transactional
	public List<Session> findByUserId(int userId) {
		
		return sessionRepo.findByUserId(userId);
	}
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findByDate(java.sql.Timestamp)
	 */
	@Override
	@Transactional
	public List<Session> findByDate(Timestamp timeStamp){
		return sessionRepo.findByDate(timeStamp);
	}
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findByGreaterStartTime(java.sql.Timestamp)
	 */
	@Override
	@Transactional
	public List<Session> findByGreaterStartTime(Timestamp timeStamp){
		return sessionRepo.findByGreaterStartTime(timeStamp);
	}
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findByLesserEndTime(java.sql.Timestamp)
	 */
	@Override
	@Transactional
	public List<Session> findByLesserEndTime(Timestamp timeStamp){
		return sessionRepo.findByLesserEndTime(timeStamp);
	}
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findByGreaterActualTime(int)
	 */
	@Override
	@Transactional
	public List<Session> findByGreaterActualTime(int time){
		return sessionRepo.findByGreaterActualTime(time);
	}
	/* (non-Javadoc)
	 * @see be.pxl.spring.service.SessionServiceInterface#findByLesserActualTime(int)
	 */
	@Override
	@Transactional
	public List<Session> findByLesserActualTime(int time){
		return sessionRepo.findByLesserActualTime(time);
	}
}
